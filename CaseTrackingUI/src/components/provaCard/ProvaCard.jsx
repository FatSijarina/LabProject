import "./provaCard.scss";
const ProvaCard = ({ Id, Name, RetrievalTime, Location, Attachment }) => {
  return ( 
    <div className="card">
      <div className="card-text">
        <h2 className="card-title">{Name}</h2>
        <p className="card-details">{RetrievalTime}</p>
        <p className="card-details">{Location}</p>
        <p className="card-details">{Attachment}</p>
      </div>
    </div>
  );
};

export default ProvaCard;