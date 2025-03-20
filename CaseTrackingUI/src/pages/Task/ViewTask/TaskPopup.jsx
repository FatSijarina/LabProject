import React, { useState } from "react";
import "./TaskPop.scss";
import "../../../assets/style/toggle-switch.css";
import agent from "../../../api/agents";

const TaskPopup = ({ isOpen, setIsOpen, task }) => {
  const [title, setTitle] = useState(task.title);
  const [details, setDetails] = useState(task.details);
  const [dueDate, setDueDate] = useState(task.dueDate);
  const [statusi, setStatusi] = useState(task.statusi);

  const handleClose = () => {
    setIsOpen(false);
  };

  const handleSubmit = () => {
    const updatedTask = {
      ...task,
      title: title,
      details: details,
      dueDate: dueDate,
      statusi: statusi,
    };
    agent.Tasks.update(updatedTask, task.taskID);
    setIsOpen(false);
    window.location.reload();
  };

  const handleChange = () => {
    setStatusi(!statusi);
  };

  return isOpen ? (
    <div className="popup">
      <div className="popup__inner">
        <button className="popup__close-button" onClick={handleClose}>
          X
        </button>
        <div className="content">
          <h4 className="info">Task Information ID: {task.taskID}</h4>

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
              <label htmlFor="statusi">Is this task done:</label>
              <div className="toggler">
                <label className="toggle-switch">
                  <input
                    type="checkbox"
                    id="statusi"
                    name="statusi"
                    checked={statusi}
                    onChange={handleChange}
                    className="toggle-switch__input"
                  />
                  <span className="slider round"></span>
                </label>
              </div>
            </div>
            <div className="input-item">
              <button onClick={handleSubmit}>Update</button>
            </div>
          </div>
        </div>
      </div>
    </div>
  ) : (
    ""
  );
};

export default TaskPopup;