import "./TaskCard.scss";
import moment from 'moment';
import { useState } from "react";
import TaskPopup from "../../pages/Task/ViewTask/TaskPopup";

// import { Link } from "react-router-dom";
const TaskCard = ({ taskID,CaseId,title,details, dateCreated, dueDate, statusi}) => {
  const [showPopup, setShowPopup] = useState(false);

  const handleShowPopup = () => {
    setShowPopup(true);
  };

  dueDate = moment(dueDate).format('YYYY-MM-DD');
  dateCreated = moment(dateCreated).format('YYYY-MM-DD');

  return (
    <div className="cardT row">

      <TaskPopup isOpen={showPopup} setIsOpen={setShowPopup} task={{ title, details, dueDate, taskID, statusi }} />
      

      <div className="main-text column">
        <p className="cardT-id">ID: {taskID}</p>
        <p className="cardT-id">caseID: {CaseId}</p>
        <div className="row">
        <h1 className="cardT-title">{title}</h1>
        
        {statusi ? <h1 className="cardT-status done">Done</h1> 
        : <h1 className="cardT-status">ToDo</h1> }
          
        </div>
        <p className="cardT-details">{details}</p>
        <p className="cardT-date">Created: {dateCreated}</p>
      </div>

      <div className="cardT-extra column">
        <div className="center">
        <h3 className="cardT-due">DUE: {moment(dueDate).format('DD/MM/YYYY')}</h3>
        </div>
        <div className="cardT-button">
        <button className="button" onClick={handleShowPopup} >Details</button>
        </div>
      </div>

     
    </div>
  );
};

export default TaskCard;