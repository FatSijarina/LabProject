import "./provaCard.scss";
const ProvaCard = ({ provaId, emri, koha, vendndodhja, attachment }) => {
  return ( 
    <div className="card">
      <div className="card-text">
        <p className="card-id">ID: {provaId}</p>
        <h2 className="card-title">{emri}</h2>
        <p className="card-details">{koha}</p>
        <p className="card-details">{vendndodhja}</p>
        <p className="card-details">{attachment}</p>
      </div>
    </div>
  );
};

export default ProvaCard;