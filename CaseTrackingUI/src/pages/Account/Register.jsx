import * as React from "react";
import Avatar from "@mui/material/Avatar";
import { LoadingButton } from "@mui/lab";
import CssBaseline from "@mui/material/CssBaseline";
import TextField from "@mui/material/TextField";
import Grid from "@mui/material/Grid";
import Box from "@mui/material/Box";
import LockOutlinedIcon from "@mui/icons-material/LockOutlined";
import Typography from "@mui/material/Typography";
import Container from "@mui/material/Container";
import { createTheme, ThemeProvider } from "@mui/material/styles";
import { Link, useNavigate } from "react-router-dom";
import { useForm } from "react-hook-form";
import agent from "../../api/agents.js";

function Copyright(props) {
  return (
    <Typography
      variant="body2"
      color="text.secondary"
      align="center"
      {...props}
    >
      {"Copyright © "}
      <Link color="inherit" to="/">
        Detecto
      </Link>{" "}
      {new Date().getFullYear()}
      {"."}
    </Typography>
  );
}

const defaultTheme = createTheme();

export default function Login() {
  const navigate = useNavigate();

  const {
    register,
    handleSubmit,
    setError,
    formState: { isSubmitting, errors, isValid },
  } = useForm({
    mode: "all",
  });

  function handleApiErrors(errors) {
    if (errors) {
      for (var error in errors) {
        console.log(error);
        if (error.includes("Password")) {
          setError("password", { message: error });
        } else if (error.includes("Email")) {
          setError("email", { message: error });
        } else if (error.includes("Username")) {
          setError("username", { message: error });
        }
      }
    }
  }

  return (
    <ThemeProvider theme={defaultTheme}>
      <Container component="main" maxWidth="xs">
        <CssBaseline />
        <Box
          sx={{
            marginTop: 8,
            display: "flex",
            flexDirection: "column",
            alignItems: "center",
          }}
        >
          <Avatar sx={{ m: 1, bgcolor: "#00176A" }}>
            <LockOutlinedIcon />
          </Avatar>
          <Typography component="h1" variant="h5">
            Register
          </Typography>
          <Box
            component="form"
            onSubmit={handleSubmit((data) =>
              agent.Account.register(data)
              .then(() => {
                console.log("Registration successful - you can now login");
                navigate('/login');
              })
              .catch((error) =>
                handleApiErrors(error)
              )
            )}
            noValidate
            sx={{ mt: 1 }}
          >
            <TextField
              margin="normal"
              fullWidth
              label="Username"
              {...register("username", { required: "Username is required" })}
              error={!!errors.username}
              helperText={errors?.username?.message}
            />
            <TextField
              margin="normal"
              fullWidth
              label="Email"
              {...register("email", {
                required: "Email is required",
                pattern: {
                  value:
                    /^([a-zA-Z0-9_\-.]+)@([a-zA-Z0-9_\-.]+)\.([a-zA-Z]{2,5})$/,
                  message: "Not a valid email address",
                },
              })}
              error={!!errors.email}
              helperText={errors?.email?.message}
            />
            <TextField
              margin="normal"
              fullWidth
              label="Password"
              type="password"
              {...register("password", {
                required: "password is required",
                pattern: {
                  value: /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,20}$/,
                  message: "Password does not meet complexity requirements",
                },
              })}
              error={!!errors.password}
              helperText={errors?.password?.message}
            />
            <LoadingButton
              loading={isSubmitting}
              disabled={!isValid}
              type="submit"
              fullWidth
              variant="contained"
              sx={{ mt: 3, mb: 2, bgcolor: "#00176A" }}
            >
              Register
            </LoadingButton>
            <Grid container>
              <Grid item>
                <Link id="signUpLink" to="/login" variant="body2">
                  {"Already have an account? Sign In"}
                </Link>
              </Grid>
            </Grid>
          </Box>
        </Box>
        <Copyright sx={{ mt: 8, mb: 4 }} />
      </Container>
    </ThemeProvider>
  );
}