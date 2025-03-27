import React from "react";
import "./PersonCard.scss";

const PersonCard = ({ person, personType }) => {
  return (
    <div className="person-card">
      <h3>{person.name}</h3>
      <p>Gjinia: {person.gender === "F" ? "Femer" : "Mashkull"}</p>
      <p>Profesioni: {person.profession}</p>
      <p>Statusi: {person.status}</p>
      <p>Vendbanimi: {person.residence}</p>
      <p>Gjendja Mendore: {person.mentalState}</p>
      <p>E Kaluara: {person.background}</p>
      <p>Deklaratat:</p>
      {/* {person.statements.map((statement) => (
        <p>{statement.content}</p>
      ))} */}
      {personType === "victims" && (
        <>
          <p>Koha: {person.time}</p>
          <p>Menyra: {person.method}</p>
          <p>Gjendja: {person.condition}</p>
        </>
      )}
      {personType === "witnesses" && (
        <>
          <p>A vëzhgohet: {person.isUnderObservation ? "Po" : "Jo"}</p>
          <p>A dyshohet: {person.isSuspected ? "Po" : "Jo"}</p>
          <p>Raporti me viktimën: {person.relationToVictim}</p>
        </>
      )}
      {personType === "suspects" && <p>Dyshimi: {person.suspicion}</p>}
    </div>
  );
};

export default PersonCard;