import { useState, useEffect, useCallback } from "react";
import "../../../styles/popup.scss";
import agent from "../../../api/agents";
import ImageCard from "./ImageCard";
import ImageUpload from "./ImageUpload";

const Images = ({ caseId, setIsFileOpen, isFileOpen }) => {
  const [images, setImages] = useState([]);
  const [isFileUploadOpen, setIsFileUploadOpen] = useState(false);

  const handleClose = () => {
    setIsFileOpen((prev) => !prev);
  };

  const handleOpen = () => {
    setIsFileUploadOpen((prev) => !prev);
  };

  const fetchImages = useCallback(() => {
    agent.Files.getCaseImages(caseId).then((response) => {
      setImages(response);
    });
  }, [caseId]);

  useEffect(() => {
    fetchImages();
  }, [fetchImages]);

  return isFileOpen ? (
    <div className="popup">
      <div className="popup__inner">
        <button className="popup__close-button" onClick={handleClose}>
          X
        </button>
        <div className="popup__card-grid">
          <button className="card-layout__add-case" onClick={handleOpen}>
            Shto Foto
          </button>
          {images.map((image) => (
            <ImageCard key={image.id} image={image} />
          ))}
        </div>
      </div>
      <ImageUpload
        caseId={caseId}
        setIsFileUploadOpen={setIsFileUploadOpen}
        isFileUploadOpen={isFileUploadOpen}
        onUploadSuccess={fetchImages} 
      />
    </div>
  ) : null;
};

export default Images;
