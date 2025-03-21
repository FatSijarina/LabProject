import React, { useState, useEffect } from "react";
import "./case-list.scss";
import { CaseCard } from "../../../components";
import agent from "../../../api/agents";
import CreateCase from "../CreateCase/CreateCase";

const CaseList = () => {
  const [cases, setCases] = useState([]);
  const [isOpen, setIsOpen] = useState(false);

  const handleOpen = () => {
    setIsOpen((prev) => !prev);
  };

  useEffect(() => {
    agent.Cases.get().then((response) => {
      setCases(response);
    });
  }, []);

  return (
    <>
      <h1>Cases</h1>
      <div className="card-layout">
        <button className="card-layout__add-case" onClick={handleOpen}>
          Add Case
        </button>
        {React.Children.toArray(
          cases.map((cases) => (
            <CaseCard
              caseId={cases.id}
              imgUrl={cases.imageUrl}
              identifier={cases.identifier}
              title={cases.title}
              details={cases.details}
              status={cases.status}
            />
          ))
        )}
      </div>
      <CreateCase setIsOpen={setIsOpen} isOpen={isOpen} />
    </>
  );
};

export default CaseList;