import { useState } from "react";
import "../../../styles/popup.scss";
import {
  FormInput,
  FormSelectBool,
} from "../../../components/formComponents/FormComponents";
import agent from "../../../api/agents";

const CreatePersoni = ({ personType, setIsOpenP, isOpenP }) => {
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
    const { name, value: rawValue } = e.target;
    let value = rawValue;
    if (value === "true") value = true;
    else if (value === "false") value = false;
    else if (name === "caseId") value = parseInt(value);
    else if (name === "gender" && value.length > 1) value = value.charAt(0);
    setPersoni((prev) => ({ ...prev, [name]: value }));
  };

  const typeMap = {
    viktimat: agent.viktimat,
    victims: agent.viktimat,
    deshmitaret: agent.deshmitaret,
    witnesses: agent.deshmitaret,
    teDyshuarit: agent.teDyshuarit,
    suspects: agent.teDyshuarit,
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    const service = typeMap[personType];
    if (!service) {
      console.error("❌ Invalid personType:", personType);
      return;
    }
    service
      .create(personi)
      .then(() => {
        alert("✅ Person added successfully");
        window.location.reload();
      })
      .catch((err) => {
        console.error("❌ Submission error:", err.response?.data || err.message);
        alert("Error creating person. Check the console for details.");
      });
  };

  return isOpenP ? (
    <div className="popup">
      <div className="popup__inner">
        <button className="popup__close-button" onClick={handleClose}>X</button>
        <h1>Shto Person</h1>
        <form className="popup__form" onSubmit={handleSubmit}>
          <FormInput label="Emri" name="name" onChange={handleChange} />
          <FormInput label="Gjinia (M/F)" name="gender" onChange={handleChange} />
          <FormInput label="Profesioni" name="profession" onChange={handleChange} />
          <FormInput label="Statusi" name="status" onChange={handleChange} />
          <FormInput label="Vendbanimi" name="residence" onChange={handleChange} />
          <FormInput label="Gjendja Mendore" name="mentalState" onChange={handleChange} />
          <FormInput label="E kaluara" name="background" onChange={handleChange} />

          {["deshmitaret", "witnesses"].includes(personType) && (
            <>
              <FormInput label="Raporti me viktimen" name="relationToVictim" onChange={handleChange} />
              <FormSelectBool label="A vezhgohet" name="isUnderObservation" onChange={handleChange} />
              <FormSelectBool label="A dyshohet" name="isSuspected" onChange={handleChange} />
            </>
          )}

          {["viktimat", "victims"].includes(personType) && (
            <>
              <FormInput label="Vendi" name="location" onChange={handleChange} />
              <FormInput label="Koha" type="datetime-local" name="time" onChange={handleChange} />
              <FormInput label="Menyra" name="method" onChange={handleChange} />
              <FormInput label="Gjendja" name="condition" onChange={handleChange} />
            </>
          )}

          {["teDyshuarit", "suspects"].includes(personType) && (
            <FormInput label="Dyshimi" name="suspicion" onChange={handleChange} />
          )}

          <FormInput label="Case ID" name="caseId" type="number" onChange={handleChange} />
          <button type="submit">Shto Personin</button>
        </form>
      </div>
    </div>
  ) : null;
};

export default CreatePersoni;
