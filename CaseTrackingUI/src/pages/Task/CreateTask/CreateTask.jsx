import React,{ useEffect, useState } from "react";
import "../../../styles/popup.scss";
import "../../../assets/style/toggle-switch.css";
import {
  FormInput,
} from "../../../components/formComponents/FormComponents";
import agent from "../../../api/agents";

const CreateTask = ({ setIsOpen, isOpen }) => {

  const [Dcase, setDCase] = useState([]);
  const [selectedCase, setSelectedCase] = useState(0);
  const [task, setTask] = useState({
    title: "",
    details: "",
    dueDate: "",
    status: false,
    isCase: false,
    CaseId: 0,
  });

  useEffect(() => {
    agent.Cases.get().then((response) => {
      setDCase(response);
    });
  }, []);

  const handleClose = () => {
    setIsOpen((prev) => !prev);
  };

  const handleChange = (e) => {
    const name = e.target.name;
    const value =
      e.target.type === "checkbox" ? e.target.checked : e.target.value;
      setSelectedCase(e.target.value)
    setTask((prev) => {
      return { ...prev, [name]: value };
    });
    
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    agent.Tasks.create(task)
      .then(task => setTask(task))
      .catch(function (error) { console.log(error.response.data) });
    window.location.reload();
  };



  return isOpen ? (
    <div className="popup">
      <div className="popup__inner">
        <button className="popup__close-button" onClick={handleClose}>
          X
        </button>
        <h1>Shto taskun</h1>
        <form className="popup__form" onSubmit={handleSubmit}>
          <FormInput
            label="Title"
            type="text"
            name="title"
            placeholder="title"
            onChange={handleChange}
          />
          <FormInput
            label="Details"
            type="text"
            name="details"
            placeholder="details"
            onChange={handleChange}
          />
          <FormInput
            label="Due Date"
            type="date"
            name="dueDate"
            onChange={handleChange}
          />
          <div>
            <label htmlFor="status" >
              Is this task done:
            </label>
            <div className="toggler">
              <label className="toggle-switch">
                <input
                  type="checkbox"
                  id="status"
                  name="status"
                  checked={task.status}
                  onChange={handleChange}
                  className="toggle-switch__input"
                />
                <span className="slider round"></span>
              </label>

            </div>
          </div>

          <div>        
              <div className="select-container">
                  <select
                  name="CaseId"
                  value={selectedCase} 
                  onChange={handleChange}>
                    <option value="">Select a case</option>
                    {Dcase.map(caseItem => (
                      <option key={caseItem.id} value={caseItem.id}>
                        {caseItem.title}
                      </option>
                      
                    ))}
                  </select>
                  
                </div>

            </div>

          <button type="submit">Shto taskun</button>
        </form>
      </div>
    </div>
  ) : (
    ""
  );
};

export default CreateTask;