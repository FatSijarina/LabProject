import "./styles.scss";
import Typography from "@mui/material/Typography";

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
            <button className="link-button" onClick={() => alert('About us clicked')}>About us</button>{" "}
          </li>
          <li>
            {" "}
            <button className="link-button" onClick={() => alert('Terms and conditions clicked')}> Terms and conditions </button>{" "}
          </li>
          <li>
            {" "}
            <button className="link-button" onClick={() => alert('Privacy Policy clicked')}> Privacy Policy </button>{" "}
          </li>
        </ul>
        <Copyright sx={{ mt: 8, mb: 4, color: "#C8D4FF" }} />
      </div>
    </section>
  );
}