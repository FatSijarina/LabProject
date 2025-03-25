import React, { useState } from "react";
import "./TaskPop.scss";
import "../../../assets/style/toggle-switch.css";
import agent from "../../../api/agents";

const TaskPopup = ({ isOpen, setIsOpen, task, onUpdate }) => {
  const [title, setTitle] = useState(task.title);
  const [details, setDetails] = useState(task.details);
  const [dueDate, setDueDate] = useState(task.dueDate);
  const [status, setStatus] = useState(task.status);
  const [isLoading, setIsLoading] = useState(false);

  const handleClose = () => {
    setIsOpen(false);
  };

  const handleSubmit = () => {
    const updatedTask = {
      id: task.id,
      title,
      details,
      dueDate,
      status,
      caseId: task.caseId ?? null,
      dateCreated: task.dateCreated,
    };

    setIsLoading(true);
    agent.Tasks.update(updatedTask, task.id)
      .then(() => {
        console.log("✅ Task updated");
        if (onUpdate) onUpdate(updatedTask);
        setIsOpen(false);
      })
      .catch((error) => {
        console.error("❌ Update failed:", error.response?.data || error.message);
        alert("Failed to update the task. See console for details.");
      })
      .finally(() => setIsLoading(false));
  };

  const handleChange = () => {
    setStatus(!status);
  };

  return isOpen ? (
    <div className="popup">
      <div className="popup__inner">
        <button className="popup__close-button" onClick={handleClose}>X</button>
        <div className="content">
          <h4 className="info">Task Information ID: {task.id}</h4>

          <h1 className="title">
            <input
              type="text"
              value={title}
              onChange={(e) => setTitle(e.target.value)}
            />
          </h1>
          <div className="details">
            <textarea
              value={details}
              onChange={(e) => setDetails(e.target.value)}
            />
          </div>
          <div className="input-group">
            <div className="input-item">
              <label htmlFor="due-date-filter">Due Date:</label>
              <input
                type="date"
                id="due-date-filter"
                value={dueDate}
                onChange={(e) => setDueDate(e.target.value)}
              />
            </div>
            <div className="input-item">
              <label htmlFor="status">Is this task done:</label>
              <div className="toggler">
                <label className="toggle-switch">
                  <input
                    type="checkbox"
                    id="status"
                    name="status"
                    checked={status}
                    onChange={handleChange}
                    className="toggle-switch__input"
                  />
                  <span className="slider round"></span>
                </label>
              </div>
            </div>
            <div className="input-item">
              <button onClick={handleSubmit} disabled={isLoading}>
                {isLoading ? "Updating..." : "Update"}
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
  ) : null;
};

export default TaskPopup;