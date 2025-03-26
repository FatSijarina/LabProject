import React from "react";
import "./image-card.scss";

const ImageCard = ({ image }) => {
  return (
    <div className="card__image">
      <p>{image.fileName.substring(0, image.fileName.length - 4)}</p>
      <p>{image.dateUploaded.substring(0, 10)}</p>
      <img src={`data:image/png;base64,${image.fileData}`} alt={image.fileName} />
    </div>
  );
};

export default ImageCard;