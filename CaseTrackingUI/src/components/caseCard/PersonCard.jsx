import React from "react";
import "./PersonCard.scss";

const PersonCard = ({ person, personType }) => {
  return (
    <div className="person-card">
      {console.log(person)}
      <h3>{person.emri}</h3>
      <p>Gjinia: {person.gjinia === "F" ? "Femer" : "Mashkull"}</p>
      <p>Profesioni: {person.profesioni}</p>
      <p>Statusi: {person.statusi}</p>
      <p>Vendbanimi: {person.vendbanimi}</p>
      <p>Gjendja Mendore: {person.gjendjaMendore}</p>
      <p>E Kaluara: {person.eKaluara}</p>
      <p>Deklaratat:</p>
      {person.deklaratat.map((deklarata) => (
        <p>Hello</p>
        //<p>{deklarata.permbajtja}</p>
      ))}
      {personType === "viktimat" && (
        <>
          <p>Koha: {person.koha}</p>
          <p>Menyra: {person.menyra}</p>
          <p>Gjendja: {person.gjendja}</p>
        </>
      )}
      {personType === "deshmitaret" && (
        <>
          <p>A vëzhgohet: {person.vezhgohet ? "Po" : "Jo"}</p>
          <p>A dyshohet: {person.dyshohet ? "Po" : "Jo"}</p>
          <p>Raporti me viktimën: {person.raportiMeViktimen}</p>
        </>
      )}
      {personType === "teDyshuarit" && <p>Dyshimi: {person.dyshimi}</p>}
    </div>
  );
};

export default PersonCard;