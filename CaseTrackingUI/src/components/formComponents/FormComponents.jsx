import { Children } from "react";
import "./form-components.scss";
import { caseStatus } from "../../api/localApi";
export const FormInput = (props) => {
  return (
    <div className="form">
      <label htmlFor={props.name}>{props.label}</label>
      <input
        required={props.required}
        name={props.name}
        placeholder={props.placeholder}
        type={props.type}
        onChange={props.onChange}
      />
    </div>
  );
};

export const FormSelect = (props) => {
  return (
    <div className="form">
      <label htmlFor={props.name}>{props.label}</label>
      <select onChange={props.onChange} name={props.name} required>
        <option value="">Zgjedh</option>
        {Children.toArray(
          props?.objects?.map((object) => (
            <option value={object?.id}>{object[props.objectName]}</option>
          ))
        )}
      </select>
    </div>
  );
};

export const FormSelectBool = (props) => {
  return (
    <div className="form">
      <label htmlFor={props.name}>{props.label}</label>
      <select onChange={props.onChange} name={props.name} required>
        <option value="">Choose</option>
        <option value={true}>Yes</option>
        <option value={false}>No</option>
      </select>
    </div>
  );
};

export const FormSelectStatusi = (props) => {
  return (
    <div className="form">
      <label htmlFor="statusi">Status</label>
      <select onChange={props.onChange} name={props.name} required>
        <option value="">Choose</option>
        {Children.toArray(
          caseStatus.map((statusi) => (
            <option value={statusi}>{statusi}</option>
          ))
        )}
      </select>
    </div>
  );
};