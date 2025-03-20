import "./styles.scss";
import Typography from "@mui/material/Typography";
import { Link } from "react-router-dom";

export default function Footer() {
  function Copyright(props) {
    return (
      <Typography
        variant="body2"
        color="#C8D4FF"
        align="center"
        {...props}
      >
        {"Copyright © Detecto "}
        {new Date().getFullYear()}
        {"."}
      </Typography>
    );
  }

  return (
    <section className="footer">
      <div className="container">
        <ul className="list">
          <li>
            {" "}
            <a href="#">About us </a>{" "}
          </li>
          <li>
            {" "}
            <a href="#"> Terms and conditions </a>{" "}
          </li>
          <li>
            {" "}
            <a href="#"> Privacy Policy </a>{" "}
          </li>
        </ul>
        <Copyright sx={{ mt: 8, mb: 4, color: "#C8D4FF" }} />
      </div>
    </section>
  );
}