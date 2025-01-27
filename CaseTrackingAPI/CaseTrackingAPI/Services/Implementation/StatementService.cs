using AutoMapper;
using CaseTrackingAPI.Configurations;
using CaseTrackingAPI.DTOs;
using CaseTrackingAPI.Models;
using CaseTrackingAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CaseTrackingAPI.Services.Implementation
{
    public class StatementService : IStatementService
    {
        private readonly CaseDbContext _context;
        private readonly IMapper _mapper;

        public StatementService(CaseDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult<List<StatementDTO>>> GetStatements() =>
            _mapper.Map<List<StatementDTO>>(await _context.Statements.ToListAsync());

        public async Task<ActionResult<StatementDTO>> GetStatementById(int id)
        {
            var mappedStatement = _mapper.Map<StatementDTO>(await _context.Statements.FindAsync(id));
            return mappedStatement == null
                ? new NotFoundObjectResult("The statement does not exist!")
                : new OkObjectResult(mappedStatement);
        }

        public async Task<ActionResult<List<StatementDTO>>> GetPersonStatements(int id)
        {
            var dbPerson = await _context.Persons.FindAsync(id);
            return dbPerson == null
                ? new NotFoundObjectResult("The person does not exist!")
                : _mapper.Map<List<StatementDTO>>(await _context.Statements
                                .Where(p => p.Person.Id == id)
                                .ToListAsync());
        }

        public async Task<ActionResult<string>> GetStatementContent(int id)
        {
            var dbContent = await _context.Statements.FindAsync(id);
            return dbContent == null
                ? new NotFoundObjectResult("The statement does not exist!")
                : dbContent.Content;
        }

        public async Task<ActionResult> AddStatement(StatementDTO statementDTO)
        {
            if (statementDTO == null)
                return new BadRequestObjectResult("The statement cannot be null!");
            var mappedStatement = _mapper.Map<Statement>(statementDTO);
            await _context.Statements.AddAsync(mappedStatement);
            await _context.SaveChangesAsync();
            return new OkObjectResult("The statement was successfully added!");
        }

        public async Task<ActionResult> UpdateStatement(int id, UpdateStatementDTO updateStatementDTO)
        {
            if (updateStatementDTO == null)
                return new BadRequestObjectResult("The statement cannot be null!");

            var dbStatement = await _context.Statements.FindAsync(id);
            if (dbStatement == null)
                return new NotFoundObjectResult("The statement does not exist!");

            dbStatement.DateGiven = updateStatementDTO.DateGiven ?? dbStatement.DateGiven;
            dbStatement.Content = updateStatementDTO.Content ?? dbStatement.Content;
            await _context.SaveChangesAsync();

            return new OkObjectResult("The statement was successfully updated!");
        }

        public async Task<ActionResult> DeleteStatement(int id)
        {
            var dbStatement = await _context.Statements.FindAsync(id);
            if (dbStatement == null)
                return new NotFoundObjectResult("The statement does not exist!");

            _context.Statements.Remove(dbStatement);
            await _context.SaveChangesAsync();
            return new OkObjectResult("The statement was successfully deleted!");
        }

        public async Task<string> CompareStatements(int s1Id, int s2Id)
        {
            Statement s1 = await _context.Statements.FindAsync(s1Id);
            Statement s2 = await _context.Statements.FindAsync(s2Id);

            if (s1 == null)
                return "The first statement is empty!";
            if (s2 == null)
                return "The second statement is empty!";

            var statement1 = (await GetStatementContent(s1Id)).Value;
            var statement2 = (await GetStatementContent(s2Id)).Value;

            if (s1.PersonId != s2.PersonId)
                return "The statements are not from the same person!";

            /*
             * // API request payload
            string API_KEY = "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";
            string endpoint = "https://api.openai.com/v1/models/text-davinci-002/engines/text-curie/jobs";

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {API_KEY}");

            // Define the input for the API
            var input = new
            {
                prompt = "Compare the semantics of the following two strings:",
                strings = new[] { deklarata1, deklarata2 }
            };

            // Serialize the input to a JSON string
            var content = new StringContent(JsonConvert.SerializeObject(input), Encoding.UTF8, "application/json");

            // Make the API request
            var response = await client.PostAsync(endpoint, content);

            // Check if the API call was successful
            if (response.IsSuccessStatusCode)
            {
                // Read the response content
                var responseContent = await response.Content.ReadAsStringAsync();

                // Deserialize the response content to a dynamic object
                dynamic responseData = JsonConvert.DeserializeObject(responseContent);

                // Extract the comparison result from the response
                bool isSemanticMatch = responseData.result;

                return (isSemanticMatch ? "The semantics of the two strings are the same." : "The semantics of the two strings are different.");
            }
            else
            {
                return ($"The API request failed with status code {(int)response.StatusCode}.");
            }
            */

            string[] str1Words = statement1.ToLower().Split(' ');
            string[] str2Words = statement2.ToLower().Split(' ');
            var uniqueWords = str2Words.Except(str1Words).ToList();

            return "First statement -> " + statement1 + "\n"
                + "Differences between the second statement and the first -> "
                + $"{String.Join(" ", uniqueWords)}";
        }
    }
}