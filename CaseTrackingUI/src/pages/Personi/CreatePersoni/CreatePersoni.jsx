import { useState } from "react";
import "../../../styles/popup.scss";
import {
  FormInput,
  FormSelectBool,
} from "../../../components/formComponents/FormComponents";
import agent from "../../../api/agents";

const CreatePersoni = ({ person, personType, setIsOpenP, isOpenP }) => {
  const [personi, setPersoni] = useState({
    emri: "",
    gjinia: "",
    profesioni: "",
    statusi: "",
    vendbanimi: "",
    gjendjaMendore: "",
    eKaluara: "",
    deklaratat: [],
    gjurmetBiologjike: [],
    vendi: "",
    koha: "",
    menyra: "",
    gjendja: "",
    raportiMeViktimen: "",
    vezhgohet: false,
    dyshohet: false,
    Dyshimi: "",
    caseId: "",
  });

  const handleClose = () => {
    setIsOpenP((prev) => !prev);
  };

  const handleChange = (e) => {
    const name = e.target.name;
    let value = e.target.value;
    if (value === "true") {
      value = true;
    } else if (value === "false") {
      value = false;
    }
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
            name="emri"
            placeholder="Emri"
            onChange={handleChange}
          />
          <FormInput
            label="Gjinia"
            type="text"
            name="gjinia"
            placeholder="Gjinia"
            onChange={handleChange}
          />
          <FormInput
            label="Profesioni"
            type="text"
            name="profesioni"
            placeholder="Profesioni"
            onChange={handleChange}
          />
          <FormInput
            label="Statusi"
            type="text"
            name="statusi"
            placeholder="Statusi"
            onChange={handleChange}
          />
          <FormInput
            label="Vendbanimi"
            type="text"
            name="vendbanimi"
            placeholder="Vendbanimi"
            onChange={handleChange}
          />
          <FormInput
            label="Gjendja Mendore"
            type="text"
            name="gjendjaMendore"
            placeholder="Gjendja Mendore"
            onChange={handleChange}
          />
          <FormInput
            label="E kaluara"
            type="text"
            name="eKaluara"
            placeholder="E kaluara"
            onChange={handleChange}
          />
          {personType === "deshmitaret" && (
            <>
              <FormInput
                label="Raporti me viktimen"
                type="text"
                name="raportiMeViktimen"
                placeholder="Raporti me viktimen"
                onChange={handleChange}
              />
              <FormSelectBool
                label="A vezhgohet"
                type="radio"
                name="vezhgohet"
                onChange={handleChange}
              />
              <FormSelectBool
                label="A dyshohet"
                type="radio"
                name="dyshohet"
                onChange={handleChange}
              />
            </>
          )}
          {personType === "viktimat" && (
            <>
              <FormInput
                label="Vendi"
                type="text"
                name="vendi"
                placeholder="Vendi"
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
                label="Menyra"
                type="text"
                name="menyra"
                placeholder="Menyra"
                onChange={handleChange}
              />
              <FormInput
                label="Gjendja"
                type="text"
                name="gjendja"
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
                name="dyshimi"
                placeholder="Dyshimi"
                onChange={handleChange}
              />
            </>
          )}
          <FormInput
            label="Case id"
            type="text"
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