import React from "react";
import "./image-card.scss";
import agent from "../../../api/agents";

const ImageCard = ({ image }) => {
  const handleDownload = async () => {
    try {
      const response = await agent.Files.downloadFile(image.id);
      
      // Create a Blob and trigger download
      const blob = new Blob([response], { type: "image/png" });
      const url = window.URL.createObjectURL(blob);
      const a = document.createElement("a");
      a.href = url;
      a.download = image.fileName; // Set the file name
      document.body.appendChild(a);
      a.click();
      window.URL.revokeObjectURL(url);
      document.body.removeChild(a);
    } catch (error) {
      console.error("Error downloading file:", error);
    }
  };

  return (
    <div className="card__image">
      <p>{image.fileName.substring(0, image.fileName.length - 4)}</p>
      <p>{image.dateUploaded.substring(0, 10)}</p>
      <img src={`data:image/png;base64,${image.fileData}`} alt={image.fileName} />
      <button className="download-button" onClick={handleDownload}>
        Download
      </button>
    </div>
  );
};

export default ImageCard;