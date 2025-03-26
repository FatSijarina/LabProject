import { useState } from "react";
import "../../../styles/popup.scss";
import {
  FormInput,
  // FormSelectStatusi,
} from "../../../components/formComponents/FormComponents";
import agent from "../../../api/agents";

const CreateProvaB = ({ setIsOpen, isOpen }) => { 
  const [provaB, setProvaB] = useState({
    Name: "",
    RetreivalTime: "",
    Location: "",
    Attachment: "",
    PersonId: "",
    Type: "",
    Specification: "",
    RetreivalTechnique: ""
  });

  const handleClose = () => {
    setIsOpen((prev) => !prev);
  };

  const handleChange = (e) => {
    const name = e.target.name;
    const value = e.target.value;
    setProvaB((prev) => {
      return { ...prev, [name]: value };
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    agent.ProvatBiologjike.create(provaB).catch(function (error) {
      console.log(error.response.data);
    });
  };

  return isOpen ? (
    <div className="popup">
      <div className="popup__inner">
        <button className="popup__close-button" onClick={handleClose}>
          X
        </button>
        <h1>Add Biological Trace</h1>
        <form className="popup__form" onSubmit={handleSubmit}>
          <FormInput
            label="Name"
            type="text"
            name="Name"
            placeholder="Name"
            onChange={handleChange}
          />
          <FormInput
            label="Retrieval Time"
            type="text"
            name="RetreivalTime"
            placeholder="Retrieval Time"
            onChange={handleChange}
          />
          <FormInput
            label="Location"
            type="text"
            name="Location"
            placeholder="Location"
            onChange={handleChange}
          />
          <FormInput
            label="Attachment"
            type="text"
            name="Attachment"
            placeholder="Attachment"
            onChange={handleChange}
          />
          <FormInput
            label="PersonId"
            type="text"
            name="PersonId"
            placeholder="PersonId"
            onChange={handleChange}
          />
          <FormInput
            label="Type"
            type="text"
            name="Type"
            placeholder="Type"
            onChange={handleChange}
          />
          <FormInput
            label="Specification"
            type="text"
            name="Specification"
            placeholder="Specification"
            onChange={handleChange}
          />
          <FormInput
            label="Retrieval Technique"
            type="text"
            name="RetreivalTechnique"
            placeholder="Retrieval Technique"
            onChange={handleChange}
          />
          <button type="submit">Add biological trace</button>
        </form>
      </div>
    </div>
  ) : (
    ""
  );
};

export default CreateProvaB;