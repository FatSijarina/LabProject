import React, { useState } from "react";
import "../../../styles/popup.scss";
import PersonCard from "../../../components/caseCard/PersonCard";
import CreatePersoni from "../../Personi/CreatePersoni/CreatePersoni";

const PersonPage = ({ personArray = [], personType, setIsOpen, isOpen, caseId }) => {
  const [isOpenP, setIsOpenP] = useState(false);

  const handleClose = () => {
    setIsOpen((prev) => !prev);
  };

  const handleOpen = () => {
    setIsOpenP((prev) => !prev);
  };

  return isOpen ? (
    <div className="popup">
      <div className="popup__inner">
        <button className="popup__close-button" onClick={handleClose}>
          X
        </button>
        <div className="popup__card-grid">
          <button className="card-layout__add-case" onClick={handleOpen}>
            Shto Personin
          </button>
          {personArray.map((person) => {
            return (
              <PersonCard
                key={person.id}
                person={person}
                personType={personType}
              />
            );
          })}
        </div>
      </div>
      <CreatePersoni
        personType={personType}
        setIsOpenP={setIsOpenP}
        isOpenP={isOpenP}
      />
    </div>
  ) : (
    ""
  );
};

export default PersonPage;