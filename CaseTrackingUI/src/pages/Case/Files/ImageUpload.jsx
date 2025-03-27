import React, { useState } from "react";
import agent from "../../../api/agents";

const ImageUpload = ({ caseId, setIsFileUploadOpen, isFileUploadOpen, onUploadSuccess }) => {
  const [file, setFile] = useState(null);
  const [error, setError] = useState(null);

  const handleClose = () => {
    setIsFileUploadOpen(false);
  };

  const handleChange = (e) => {
    const selectedFile = e.target.files[0];
    if (selectedFile && selectedFile.type === "image/png") {
      setFile(selectedFile);
      setError(null);
    } else {
      setFile(null);
      setError("Invalid file type. Only PNG images are allowed.");
    }
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    if (!file) return;

    const formData = new FormData();
    formData.append("fileData", file);

    try {
      await agent.Files.uploadfile(caseId, formData);
      console.log("File uploaded:", file);
      onUploadSuccess();
      setFile(null);
      setIsFileUploadOpen(false);
    } catch (error) {
      console.error("Upload failed:", error);
    }
  };

  return isFileUploadOpen ? (
    <div className="popup">
      <div className="popup__inner">
        <button className="popup__close-button" onClick={handleClose}>X</button>
        <form onSubmit={handleSubmit} className="popup__form">
          <input type="file" onChange={handleChange} accept="image/png" />
          {error && <p className="error">{error}</p>}
          <button type="submit">Upload</button>
        </form>
      </div>
    </div>
  ) : null;
};

export default ImageUpload;
