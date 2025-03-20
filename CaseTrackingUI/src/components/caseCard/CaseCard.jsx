import "./caseCard.scss";
import { Link } from "react-router-dom";
const CaseCard = ({ caseId, imgUrl, identifier, title, details, status }) => {
  return (
    <div className="card">
      <img src={imgUrl} alt="Case Card" />
      <div className="card-text">
        <p className="card-id">ID: {identifier}</p>
        <h2 className="card-title">{title}</h2>
        <p className="card-details">{details}</p>
      </div>
      <div className="card-buttons">
        <Link to={`../case/${caseId}`}>Details</Link>
        <button className="card-status">{status}</button>
      </div>
    </div>
  );
};

export default CaseCard;
