import { useState } from "react";
import "../../../styles/popup.scss";
import {
  FormInput,
  FormSelectBool,
} from "../../../components/formComponents/FormComponents";
import agent from "../../../api/agents";

const CreatePersoni = ({ person, personType, setIsOpenP, isOpenP }) => {
  const [personi, setPersoni] = useState({
    name: "",
    gender: "",
    profession: "",
    status: "",
    residence: "",
    mentalState: "",
    background: "",
    statements: [],
    biologicalTraces: [],
    evidences: [],
    location: "",
    time: "",
    method: "",
    condition: "",
    relationToVictim: "",
    isUnderObservation: false,
    isSuspected: false,
    suspicion: "",
    caseId: "",
  });

  const handleClose = () => {
    setIsOpenP((prev) => !prev);
  };

  const handleChange = (e) => {
    const name = e.target.name;
    let value = e.target.value;
    if (value === "true") value = true;
    else if (value === "false") value = false;
    else if (name === "caseId") value = parseInt(value);
    else if (name === "gender" && value.length > 1) value = value.charAt(0);
    setPersoni((prev) => {
      return { ...prev, [name]: value };
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    agent[personType].create(personi).catch(function (error) {
      console.log(error.response.data);
    });
  };

  return isOpenP ? (
    <div className="popup">
      <div className="popup__inner">
        <button className="popup__close-button" onClick={handleClose}>
          X
        </button>
        <h1>Shto Person</h1>
        <form className="popup__form" onSubmit={handleSubmit}>
          <FormInput
            label="Emri"
            type="text"
            name="name"
            placeholder="Emri"
            onChange={handleChange}
          />
          <FormInput
            label="Gjinia (M/F)"
            type="text"
            name="gender"
            placeholder="M or F"
            onChange={handleChange}
          />
          <FormInput
            label="Profesioni"
            type="text"
            name="profession"
            placeholder="Profesioni"
            onChange={handleChange}
          />
          <FormInput
            label="Statusi"
            type="text"
            name="status"
            placeholder="Statusi"
            onChange={handleChange}
          />
          <FormInput
            label="Vendbanimi"
            type="text"
            name="residence"
            placeholder="Vendbanimi"
            onChange={handleChange}
          />
          <FormInput
            label="Gjendja Mendore"
            type="text"
            name="mentalState"
            placeholder="Gjendja Mendore"
            onChange={handleChange}
          />
          <FormInput
            label="E kaluara"
            type="text"
            name="background"
            placeholder="E kaluara"
            onChange={handleChange}
          />
          {personType === "deshmitaret" && (
            <>
              <FormInput
                label="Raporti me viktimen"
                type="text"
                name="relationToVictim"
                placeholder="Raporti me viktimen"
                onChange={handleChange}
              />
              <FormSelectBool
                label="A vezhgohet"
                type="radio"
                name="isUnderObservation"
                onChange={handleChange}
              />
              <FormSelectBool
                label="A dyshohet"
                type="radio"
                name="isSuspected"
                onChange={handleChange}
              />
            </>
          )}
          {personType === "viktimat" && (
            <>
              <FormInput
                label="Vendi"
                type="text"
                name="location"
                placeholder="Vendi"
                onChange={handleChange}
              />
              <FormInput
                label="Koha"
                type="datetime-local"
                name="time"
                placeholder="Koha"
                onChange={handleChange}
              />
              <FormInput
                label="Menyra"
                type="text"
                name="method"
                placeholder="Menyra"
                onChange={handleChange}
              />
              <FormInput
                label="Gjendja"
                type="text"
                name="condition"
                placeholder="Gjendja"
                onChange={handleChange}
              />
            </>
          )}
          {personType === "teDyshuarit" && (
            <>
              <FormInput
                label="Dyshimi"
                type="text"
                name="suspicion"
                placeholder="Dyshimi"
                onChange={handleChange}
              />
            </>
          )}
          <FormInput
            label="Case id"
            type="number"
            name="caseId"
            placeholder="Case id"
            onChange={handleChange}
          />
          <button type="submit">Shto Personin</button>
        </form>
      </div>
    </div>
  ) : (
    ""
  );
};

export default CreatePersoni;