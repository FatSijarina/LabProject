import { useState } from "react";
import "../../../styles/popup.scss";
import {
  FormInput,
  FormSelectStatusi,
} from "../../../components/formComponents/FormComponents";
import agent from "../../../api/agents";

const CreateCase = ({ setIsOpen, isOpen }) => {
  const [dCase, setDCase] = useState({
    imageUrl: "",
    identifier: "",
    title: "",
    status: "",
    details: "",
  });

  const handleClose = () => {
    setIsOpen((prev) => !prev);
  };

  const handleChange = (e) => {
    const name = e.target.name;
    const value = e.target.value;
    setDCase((prev) => {
      return { ...prev, [name]: value };
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    agent.Cases.create(dCase).catch(function (error) {
      console.log(error.response.data);
    });
  };

  return isOpen ? (
    <div className="popup">
      <div className="popup__inner">
        <button className="popup__close-button" onClick={handleClose}>
          X
        </button>
        <h1>Add Case</h1>
        <form className="popup__form" onSubmit={handleSubmit}>
          <FormInput
            label="Image Url"
            type="text"
            name="imageUrl"
            placeholder="Image Url"
            onChange={handleChange}
          />
          <FormInput
            label="Identifier"
            type="text"
            name="identifier"
            placeholder="Identifier"
            onChange={handleChange}
          />
          <FormInput
            label="Title"
            type="text"
            name="title"
            placeholder="Title"
            onChange={handleChange}
          />
          <FormSelectStatusi name="status" onChange={handleChange} />
          <FormInput
            label="Details"
            type="text"
            name="details"
            placeholder="Details"
            onChange={handleChange}
          />
          <button type="submit">Add Case</button>
        </form>
      </div>
    </div>
  ) : (
    ""
  );
};

export default CreateCase;