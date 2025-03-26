import { useState } from "react";
import "../../../styles/popup.scss";
import {
  FormInput,
  FormSelectBool
} from "../../../components/formComponents/FormComponents";
import agent from "../../../api/agents";

const CreateProvaF = ({ setIsOpen, isOpen }) => {
  const [provaF, setProvaF] = useState({
    Name: "",
    RetreivalTime: "",
    Location: "",
    Attachment: "",
    PersonId: "",
    UsedInCrime: false,
    DangerLevel: "",
    Classification: "",
    RequiresExamination: false,
    ContainsBiologicalTraces: false
  });

  const handleClose = () => {
    setIsOpen((prev) => !prev);
  };

  const handleChange = (e) => {
    const name = e.target.name;
    let value = e.target.value;
    if(value === "true"){
      value = true
    }
    else if(value === "false"){
      value = false
    }
    setProvaF((prev) => {
      return { ...prev, [name]: value };
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    console.log(provaF);
    agent.ProvatFizike.create(provaF).catch(function (error) {
      console.log(error.response.data);
    });
  };

  return isOpen ? (
    <div className="popup">
      <div className="popup__inner">
        <button className="popup__close-button" onClick={handleClose}>
          X
        </button>
        <h1>Shto Provë Fizike</h1>
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
            type="datetime"
            name="RetrievalTime"
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
          <FormSelectBool
            label="Used in crime"
            type="radio"
            name="UsedInCrime"
            onChange={handleChange}
          />
          <FormInput
            label="Danger Level"
            type="text"
            name="DangerLevel"
            placeholder="Danger Level"
            onChange={handleChange}
          />
          <FormInput
            label="Classification"
            type="text"
            name="Classification"
            placeholder="Classification"
            onChange={handleChange}
          />
          <FormSelectBool
            label="Requires examination"
            type="radio"
            name="RequiresExamination"
            onChange={handleChange}
          />
          <FormSelectBool
            label="Contains biological traces"
            type="radio"
            name="ContainsBiologicalTraces"
            onChange={handleChange}
          />
          <button type="submit">Add physical trace</button>
        </form>
      </div>
    </div>
  ) : (
    ""
  );
};

export default CreateProvaF;