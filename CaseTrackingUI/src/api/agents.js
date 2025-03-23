import axios from 'axios';
import { store } from '../store/configureStore.ts';

// Axios instance for backend API
const backendAxios = axios.create({
  baseURL: "https://localhost:7066/api/",
});

backendAxios.interceptors.request.use(config => {
  const token = store.getState().account.user?.token;
  if (token) config.headers.Authorization = `Bearer ${token}`;
  return config;
});

const responseBody = (response) => response.data;

const requests = {
  get: (url) => backendAxios.get(url).then(responseBody),
  post: (url, body) => backendAxios.post(url, body).then(responseBody),
  put: (url, body) => backendAxios.put(url, body).then(responseBody),
  del: (url) => backendAxios.delete(url).then(responseBody),
};

const Cases = {
  get: () => requests.get('Case/cases'),
  getById: (id) => requests.get(`Case/case/${id}`),
  create: (values) => requests.post(`Case/case`, values)
};

const Files = {
  getCaseImages: (id) => requests.get(`/File/get-case-png/${id}`),
  uploadfile: (id, values) => requests.post(`/File/upload/${id}`, values)
};

const deshmitaret = {
  get: () => requests.get('Witness/witnesses'),
  create: (values) => requests.post(`Witness/witness`, values)
};

const teDyshuarit = {
  get: () => requests.get('Suspect/suspects'),
  create: (values) => requests.post(`Suspect/suspect`, values)
};

const viktimat = {
  get: () => requests.get('Victim/victims'),
  create: (values) => requests.post(`Victims/victim`, values)
};

const Provat = {
    get: () => requests.get('Evidence/evidences'),
    getById: (id) => requests.get(`Evidence/evidence/${id}`)
};
  
const ProvatBiologjike = {
    get: () => requests.get('BiologicalEvidence/biological-evidences'),
    getById: (id) => requests.get(`BiologicalEvidence/biological-evidence/${id}`),
    create: (values) => requests.post('BiologicalEvidence/biological-evidence', values)
};
  
const ProvatFizike = {
    get: () => requests.get('PhysicalEvidence/physical-evidences'),
    getById: (id) => requests.get(`PhysicalEvidence/physical-evidence/${id}`),
    create: (values) => requests.post('PhysicalEvidence/physical-evidence', values)
};

const Tasks = {
  get: () => requests.get('Task/tasks'),
  getById: (id) => requests.get(`Task/get-task-by-id/${id}`),
  create: (values) => requests.post(`Task/add-task`, values),
  update: (values, id) => requests.put(`Task/put-task/${id}`, values),
  delete: (id) => requests.del(`Task/delete-task/${id}`)
};

const Account = {
  login: (user) => requests.post('Account/login', user),
  register: (user) => requests.post('Account/register', user),
  currentUser: () => requests.get('Account/currentUser'),
};

// Axios instance for OpenAI API
const openAIAxios = axios.create({
  baseURL: "https://api.openai.com/v1/",
});

const API_KEY = process.env.REACT_APP_OPENAI_API_KEY;

export const fetchChatGPTResponse = async (userMessage) => {
  try {
    console.log("Sending request to OpenAI API with message:", userMessage);
    console.log("Using API Key:", API_KEY);

    const response = await openAIAxios.post(
      "chat/completions",
      {
        model: "gpt-3.5-turbo", // or "gpt-4" if available
        messages: [
          { role: "system", content: "You are an AI detective assistant helping to solve crimes. Respond in a professional, investigative tone, analyzing information step by step, and providing possible theories and actions detectives can take. Keep it short and precise to the point." },
          { role: "user", content: userMessage }
        ],
      },
      {
        headers: {
          "Content-Type": "application/json",
          Authorization: `Bearer ${API_KEY}`,
        },
      }
    );

    console.log("Received response from OpenAI API:", response.data);
    return response.data.choices[0].message.content;
  } catch (error) {
    console.error("Error fetching ChatGPT response:", error);
    if (error.response) {
      console.error("Response data:", error.response.data);
      console.error("Response status:", error.response.status);
      console.error("Response headers:", error.response.headers);
    }
    return "Error: Unable to fetch response";
  }
};

const agent = {
  Cases,
  Files,
  deshmitaret,
  teDyshuarit,
  viktimat,
  Provat,
  ProvatBiologjike,
  ProvatFizike,
  Tasks,
  Account,
};

export default agent;