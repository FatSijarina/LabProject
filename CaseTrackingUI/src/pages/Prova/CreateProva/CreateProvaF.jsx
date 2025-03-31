import { useState } from "react";
import "../../../styles/popup.scss";
import {
  FormInput,
  FormSelectBool,
} from "../../../components/formComponents/FormComponents";
import agent from "../../../api/agents";

const CreateProvaF = ({ setIsOpen, isOpen }) => {
  const [provaF, setProvaF] = useState({
    name: "",
    retrievalTime: new Date().toISOString(), // Set default to current time
    location: "",
    attachment: "",
    personId: 1, // Default valid personId (ensure this is selectable)
    usedInCrime: false,
    dangerLevel: "",
    classification: "",
    requiresExamination: false,
    containsBiologicalTraces: false,
  });

  const handleClose = () => {
    setIsOpen((prev) => !prev);
  };

  const handleChange = (e) => {
    const { name, value } = e.target;
    let newValue = value;

    if (name === "personId") {
      newValue = parseInt(value, 10) || ""; // Ensure it's an integer
    } else if (value === "true") {
      newValue = true;
    } else if (value === "false") {
      newValue = false;
    }

    setProvaF((prev) => ({
      ...prev,
      [name]: newValue,
    }));
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    try {
      await agent.ProvatFizike.create(provaF);
      window.location.reload(); // Reload the page after successful submission
    } catch (error) {
      console.error("Error submitting form:", error.response?.data || error);
    }
  };

  return isOpen ? (
    <div className="popup">
      <div className="popup__inner" style={{ maxHeight: "90vh", overflowY: "auto", width: "90vw", padding: "20px" }}>
        <button className="popup__close-button" onClick={handleClose}>
          X
        </button>
        <h1>Add Physical Evidence</h1>
        <form className="popup__form" onSubmit={handleSubmit}>
          <FormInput
            label="Name"
            type="text"
            name="name"
            placeholder="Name"
            onChange={handleChange}
          />
          <FormInput
            label="Retrieval Time"
            type="datetime-local"
            name="retrievalTime"
            placeholder="Retrieval Time"
            onChange={handleChange}
          />
          <FormInput
            label="Location"
            type="text"
            name="location"
            placeholder="Location"
            onChange={handleChange}
          />
          <FormInput
            label="Attachment"
            type="text"
            name="attachment"
            placeholder="Attachment"
            onChange={handleChange}
          />
          <FormInput
            label="Person ID"
            type="number"
            name="personId"
            placeholder="Person ID"
            onChange={handleChange}
          />
          <FormSelectBool
            label="Used in crime"
            name="usedInCrime"
            onChange={handleChange}
          />
          <FormInput
            label="Danger Level"
            type="text"
            name="dangerLevel"
            placeholder="Danger Level"
            onChange={handleChange}
          />
          <FormInput
            label="Classification"
            type="text"
            name="classification"
            placeholder="Classification"
            onChange={handleChange}
          />
          <FormSelectBool
            label="Requires examination"
            name="requiresExamination"
            onChange={handleChange}
          />
          <FormSelectBool
            label="Contains biological traces"
            name="containsBiologicalTraces"
            onChange={handleChange}
          />
          <button type="submit">Add Physical Evidence</button>
        </form>
      </div>
    </div>
  ) : (
    ""
  );
};

export default CreateProvaF;
