import { useState } from "react";
import "../../../styles/popup.scss";
import {
  FormInput,
  FormSelectBool
} from "../../../components/formComponents/FormComponents";
import agent from "../../../api/agents";

const CreateProvaF = ({ setIsOpen, isOpen }) => {
  const [provaF, setProvaF] = useState({
    emri: "",
    koha: "",
    vendndodhja: "",
    attachment: "",
    personiId: "",
    ePerdorurNeKrim: false,
    rrezikshmeria: "",
    klasifikimi: "",
    duhetEkzaminim: false,
    kaGjurmeBiologjike: false
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
            label="Emri"
            type="text"
            name="emri"
            placeholder="Emri"
            onChange={handleChange}
          />
          <FormInput
            label="Koha"
            type="datetime"
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
          <FormSelectBool
            label="E përdorur në krim"
            type="radio"
            name="ePerdorurNeKrim"
            onChange={handleChange}
          />
          <FormInput
            label="Rrezikshmeria"
            type="text"
            name="rrezikshmeria"
            placeholder="Rrezikshmeria"
            onChange={handleChange}
          />
          <FormInput
            label="Klasifikimi"
            type="text"
            name="klasifikimi"
            placeholder="Klasifikimi"
            onChange={handleChange}
          />
          <FormSelectBool
            label="Duhet ekzaminim"
            type="radio"
            name="duhetEkzaminim"
            onChange={handleChange}
          />
          <FormSelectBool
            label="Ka gjurme biologjike"
            type="radio"
            name="kaGjurmeBiologjike"
            onChange={handleChange}
          />
          <button type="submit">Shto Provën Fizike</button>
        </form>
      </div>
    </div>
  ) : (
    ""
  );
};

export default CreateProvaF;