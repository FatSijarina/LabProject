import React, { useState, useEffect } from "react";
import "./prova-list.scss";
import { ProvaCard } from "../../../components";
import agent from "../../../api/agents";
import CreateProvaB from "../CreateProva/CreateProvaB";
import CreateProvaF from "../CreateProva/CreateProvaF";

const ProvaList = ({ provaType, setIsOpenP, isOpenP }) => {
  const [provat, setProvat] = useState([]);
  const [isOpenB, setIsOpenB] = useState(false);
  const [isOpenF, setIsOpenF] = useState(false);

  const handleClose = () => {
    setIsOpenP((prev) => !prev);
  };
  const handleOpenB = () => {
    setIsOpenB((prev) => !prev);
  };
  const handleOpenF = () => {
    setIsOpenF((prev) => !prev);
  };

  useEffect(() => {
    agent[provaType].get().then((response) => {
      setProvat(response);
    });
  }, [provaType]);

  return isOpenP ? (
    <div className="popup">
      <div className="popup__inner">
        <button className="popup__close-button" onClick={handleClose}>
          X
        </button>
        <div className="popup__card-grid">
          {provaType === "ProvatFizike" && (
            <button className="card-layout__add" onClick={handleOpenF}>
              Shto Provë Fizike
            </button>
          )}
          {provaType === "ProvatBiologjike" && (
            <button className="card-layout__add" onClick={handleOpenB}>
              Shto Provë Biologjike
            </button>
          )}
          {React.Children.toArray(
            provat.map((provat) => (
              <ProvaCard
                Id={provat.Id}
                Name={provat.Name}
                RetrievalTime={provat.RetrievalTime}
                Location={provat.Location}
                Attachment={provat.Attachment}
              />
            ))
          )}
        </div>
      </div>
      {provaType === "ProvatFizike" && (
        <CreateProvaF setIsOpen={setIsOpenF} isOpen={isOpenF} />
      )}
      {provaType === "ProvatBiologjike" && (
        <CreateProvaB setIsOpen={setIsOpenB} isOpen={isOpenB} />
      )}
    </div>
  ) : (
    ""
  );
};

export default ProvaList;