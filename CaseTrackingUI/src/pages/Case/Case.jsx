import React, { useState, useEffect } from "react";
import "./case.scss";
import { useParams } from "react-router-dom";
import agent from "../../api/agents";
import PersonPage from "./Persons/PersonPage";
import ProvaCard from "../../components/provaCard/ProvaCard";

import ProvaList from "../Prova/ProvaList/ProvaList";
import Images from "./Files/Images";

const Case = () => {
  let params = useParams();
  const [personType, setPersonType] = useState("");
  const [provaType, setProvaType] = useState("");
  const [isOpen, setIsOpen] = useState(false);
  const [isOpenP, setIsOpenP] = useState(false);
  const [isFileOpen, setIsFileOpen] = useState(false);
  const [caseData, setCaseData] = useState({
    photo: "",
    title: "",
    caseId: "",
    details: "",
    status: "",
    dateOpened: "",
    dateClosed: "",
    viktimat: [],
    deshmitaret: [],
    teDyshuarit: [],
  });

  const handleOpen = () => {
    setIsOpen((prev) => !prev);
  };
  const handleOpenFiles = () => {
    setIsFileOpen((prev) => !prev);
  };
  const handleOpenP = () => {
    setIsOpenP((prev) => !prev);
  };

  useEffect(() => {
    agent.Cases.getById(params.caseId).then((response) => {
      setCaseData(response);
    });
  }, [params.caseId]);

  return (
    <div className="case-page">
      <div className="case-page__header">
        <img src={caseData.imageUrl} alt={caseData.title} />
        <div className="case-page__title">
          <h1>{caseData.title}</h1>
          <p>{caseData.identifier}</p>
          <p className="case-page__status">Status: {caseData.status}</p>
          <p className="case-page__date-opened">
            Date Opened: {caseData.dateOpened}
          </p>
          <p className="case-page__date-closed">
            Date Closed: {caseData.dateClosed}
          </p>
        </div>
      </div>
      <div className="case-page__details">
        <h1>Detajet</h1>
        <p> {caseData.details}</p>
      </div>
      <div className="case-page__files">
        <button
          onClick={() => {
            handleOpenFiles();
          }}
        >
          Files
        </button>
      </div>
      <Images
        setIsFileOpen={setIsFileOpen}
        caseId={params.caseId}
        isFileOpen={isFileOpen}
      />
      <div className="case-page__persons">
        <h1>Palet</h1>
        <div className="case-page__persons-list">
          <button
            onClick={() => {
              handleOpen();
              setPersonType("viktimat");
            }}
          >
            {caseData.viktimat.length} Viktima
          </button>
          <button
            onClick={() => {
              handleOpen();
              setPersonType("deshmitaret");
            }}
          >
            {caseData.deshmitaret.length} Deshmitare
          </button>
          <button
            onClick={() => {
              handleOpen();
              setPersonType("teDyshuarit");
            }}
          >
            {caseData.teDyshuarit.length} Te Dyshuar
          </button>
        </div>
      </div>
      <PersonPage
        personArray={caseData[personType]}
        personType={personType}
        setIsOpen={setIsOpen}
        isOpen={isOpen}
      />
      <div className="case-page__persons">
        <h1>Provat</h1>
        <div className="case-page__persons-prova">
          <button
            onClick={() => {
              handleOpenP();
              setProvaType("ProvatBiologjike");
            }}
          >
            Provat Biologjike
          </button>
          <button
            onClick={() => {
              handleOpenP();
              setProvaType("ProvatFizike");
            }}
          >
            Provat Fizike
          </button>
        </div>
      </div>
      {isOpenP != false ? (
        <ProvaList
          provaType={provaType}
          setIsOpenP={setIsOpenP}
          isOpenP={isOpenP}
        />
      ) : (
        " "
      )}
    </div>
  );
};

export default Case;