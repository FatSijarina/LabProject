import { useState } from "react";
import "../../../styles/popup.scss";
import {
  FormInput,
  // FormSelectStatusi,
} from "../../../components/formComponents/FormComponents";
import agent from "../../../api/agents";

const CreateProvaB = ({ setIsOpen, isOpen }) => { 
  const [provaB, setProvaB] = useState({
    emri: "",
    koha: "",
    vendndodhja: "",
    attachment: "",
    personiId: "",
    lloji: "",
    specifikimi: "",
    teknikaENxjerrjes: ""
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
        <h1>Shto Provë Biologjike</h1>
        <form className="popup__form" onSubmit={handleSubmit}>
          <FormInput
            label="Emri"
            type="text"
            name="emri"
            placeholder="Emri"
            onChange={handleChange}
          />
          <FormInput
            label="Koha"
            type="text"
            name="koha"
            placeholder="Koha"
            onChange={handleChange}
          />
          <FormInput
            label="Vendndodhja"
            type="text"
            name="vendndodhja"
            placeholder="Vendndodhja"
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
            label="PersoniId"
            type="text"
            name="personiId"
            placeholder="PersoniId"
            onChange={handleChange}
          />
          <FormInput
            label="Lloji"
            type="text"
            name="lloji"
            placeholder="Lloji"
            onChange={handleChange}
          />
          <FormInput
            label="Specifikimi"
            type="text"
            name="specifikimi"
            placeholder="Specifikimi"
            onChange={handleChange}
          />
          <FormInput
            label="Teknika e nxjerrjes"
            type="text"
            name="teknikaENxjerrjes"
            placeholder="Teknika e nxjerrjes"
            onChange={handleChange}
          />
          <button type="submit">Shto Provën Biologjike</button>
        </form>
      </div>
    </div>
  ) : (
    ""
  );
};

export default CreateProvaB;