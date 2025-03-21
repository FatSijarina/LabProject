import "./deshmitariCard.scss";
// import { Link } from "react-router-dom";
const DeshmitariCard = ({ deshmitariId, emri, gjinia, profesioni}) => {
  return ( 
    <div className="card">
      <div className="card-text">
        <p className="card-id">ID: {deshmitariId}</p>
        <h2 className="card-title">{emri}</h2>
        <p className="card-details">{gjinia}</p>
        <p className="card-details">{profesioni}</p>
      </div>
    </div>
  );
};

export default DeshmitariCard;