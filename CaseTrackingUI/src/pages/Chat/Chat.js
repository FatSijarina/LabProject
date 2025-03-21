import React, { useState, useRef, useEffect } from "react";
import { fetchChatGPTResponse } from "../../api/agents";
import "./Chat.css";
import { FaUserSecret, FaSearch, FaFolderOpen, FaBook, FaTrash, FaEye, FaSave, FaFolderOpen as FaLoad } from "react-icons/fa";

const Chat = () => {
  const [userInput, setUserInput] = useState("");
  const [messages, setMessages] = useState([]);
  const messagesEndRef = useRef(null);
  const [evidence, setEvidence] = useState([]);
  const [notebook, setNotebook] = useState(localStorage.getItem("detectiveNotebook") || "");
  const [revealedEvidence, setRevealedEvidence] = useState(null);
  const [isTyping, setIsTyping] = useState(false);
  const [savedCases, setSavedCases] = useState([]);

  useEffect(() => {
    messagesEndRef.current?.scrollIntoView({ behavior: "smooth" });
    loadCases();
  }, [messages]);

  const handleSend = async () => {
    if (!userInput.trim()) return;

    setMessages([...messages, { role: "user", content: userInput }]);
    setUserInput("");
    setIsTyping(true);

    const response = await fetchChatGPTResponse(userInput);

    setMessages((prev) => [...prev, { role: "assistant", content: response }]);
    setIsTyping(false);
  };

  const handleKeyPress = (e) => {
    if (e.key === "Enter") {
      e.preventDefault();
      handleSend();
    }
  };

  const addEvidence = (message) => {
    if (!evidence.some(e => e.content === message)) {
      setEvidence([...evidence, { id: evidence.length + 1, content: message }]);
    }
  };

  const toggleEvidence = (id) => {
    setRevealedEvidence(revealedEvidence === id ? null : id);
  };

  const handleNotebookChange = (e) => {
    setNotebook(e.target.value);
    localStorage.setItem("detectiveNotebook", e.target.value);
  };

  const clearNotebook = () => {
    setNotebook("");
    localStorage.removeItem("detectiveNotebook");
  };

  const saveCase = () => {
    const caseData = { messages, evidence, notebook };
    localStorage.setItem("case_" + Date.now(), JSON.stringify(caseData));
    loadCases();
  };

  const loadCases = () => {
    const cases = Object.keys(localStorage)
      .filter((key) => key.startsWith("case_"))
      .sort()
      .map((key, index) => ({ id: key, name: `Case ${index + 1}`, data: JSON.parse(localStorage.getItem(key)) }));
    setSavedCases(cases);
  };

  const loadCase = (caseData) => {
    setMessages(caseData.messages);
    setEvidence(caseData.evidence);
    setNotebook(caseData.notebook);
  };

  return (
    <div className="chat-container">
      <h1 className="chat-title">
        <FaUserSecret /> Detective AI Partner
      </h1>
      <div className="chat-layout">
        <div className="evidence-panel box">
          <h2>Case Evidence</h2>
          {evidence.length === 0 ? (
            <p>No evidence collected.</p>
          ) : (
            <ul>
              {evidence.map((item) => (
                <li key={item.id}>
                  <button className="evidence-toggle" onClick={() => toggleEvidence(item.id)}>
                    Evidence {item.id} <FaEye />
                  </button>
                  {revealedEvidence === item.id && <p className="evidence-content">{item.content}</p>}
                </li>
              ))}
            </ul>
          )}
        </div>
        <div className="chat-box box">
          {messages.map((msg, index) => (
            <div key={index} className={`message ${msg.role}`}>
              <span className="message-content">{msg.content}</span>
              {msg.role === "assistant" && (
                <div className="evidence-btn-container">
                  <button className="evidence-btn" onClick={() => addEvidence(msg.content)}>
                    <FaFolderOpen /> Add to Evidence
                  </button>
                </div>
              )}
            </div>
          ))}
          {isTyping && <p className="typing-indicator">Detective AI is analyzing...</p>}
          <div ref={messagesEndRef} />
        </div>
        <div className="notebook-panel box">
          <h2><FaBook /> Detective Notebook</h2>
          <textarea
            value={notebook}
            onChange={handleNotebookChange}
            placeholder="Write down your case notes here..."
          />
          <button className="clear-btn" onClick={clearNotebook}><FaTrash /> Clear Notebook</button>
          <button className="save-case-btn" onClick={saveCase}><FaSave /> Save Case</button>
          <div className="saved-cases">
            <h3>Saved Cases</h3>
            {savedCases.length === 0 ? (
              <p>No saved cases.</p>
            ) : (
              <ul>
                {savedCases.map((savedCase) => (
                  <li key={savedCase.id}>
                    <button className="load-case-btn" onClick={() => loadCase(savedCase.data)}>
                      <FaLoad /> {savedCase.name}
                    </button>
                  </li>
                ))}
              </ul>
            )}
          </div>
        </div>
      </div>
      <div className="chat-input">
        <input
          type="text"
          value={userInput}
          onChange={(e) => setUserInput(e.target.value)}
          onKeyDown={handleKeyPress}
          placeholder="Interrogate the AI..."
        />
        <button onClick={handleSend}><FaSearch /> Analyze</button>
      </div>
    </div>
  );
};

export default Chat;