import Logo from "../../assets/brand/logo-detecto.svg";
import { Link, NavLink, useNavigate } from "react-router-dom";
import * as React from "react";
import AppBar from "@mui/material/AppBar";
import Box from "@mui/material/Box";
import Toolbar from "@mui/material/Toolbar";
import IconButton from "@mui/material/IconButton";
import Typography from "@mui/material/Typography";
import Menu from "@mui/material/Menu";
import Container from "@mui/material/Container";
import Avatar from "@mui/material/Avatar";
import Tooltip from "@mui/material/Tooltip";
import MenuItem from "@mui/material/MenuItem";
import { useAppDispatch, useAppSelector } from "../../store/configureStore.ts";
import { Button } from "@mui/material";
import { signOut } from "../../pages/Account/AccountSlice.ts";

const pages = [
  {
    name: "Home",
    path: "/",
  },
  {
    name: "Cases",
    path: "./cases",
  },
  {
    name: "Tasks",
    path: "./tasks",
  },
  {
    name: "Statistics",
    path: "./statistics",
  },
  {
    name: "Chat",
    path: "./chat",
  },
  {
    name: "Predictions",
    path: "./predictions",
  },
].filter(Boolean);

function ResponsiveAppBar() {
  const dispatch = useAppDispatch();
  const navigate = useNavigate();
  const { user } = useAppSelector((state) => state.account);
  const [anchorElUser, setAnchorElUser] = React.useState(null);

  const handleOpenUserMenu = (event) => {
    setAnchorElUser(event.currentTarget);
  };

  const handleCloseUserMenu = () => {
    setAnchorElUser(null);
  };

  const handleSignOut = () => {
    dispatch(signOut());
    navigate("/");
  };

  return (
    <AppBar
      position="static"
      style={{ background: "transparent", boxShadow: "none" }}
    >
      <Container maxWidth="xl">
        <Toolbar disableGutters>
          <Link to="/" className="logo">
            <img src={Logo} alt="Our logo." style={{ width: "50px" }} />
          </Link>
          <Box sx={{ flexGrow: 1, display: { xs: "none", md: "flex" } }}>
            {pages.map((page) => {
              // Only show protected pages if the user is logged in
              if (
                ["Cases", "Tasks", "Statistics", "Predictions", "Chat"].includes(
                  page.name
                ) &&
                !user
              ) {
                return null; // Hide the link if the user is not logged in
              }
              return (
                <NavLink
                  key={page.name}
                  to={page.path}
                  className="navlink"
                  style={{ margin: "0 10px" }}
                >
                  {page.name}
                </NavLink>
              );
            })}
          </Box>
          {user? (
            <Box sx={{ flexGrow: 0 }}>
              <Tooltip title="Open settings">
                <IconButton onClick={handleOpenUserMenu} sx={{ p: 0 }}>
                  <Avatar alt="Remy Sharp" src="/static/images/avatar/2.jpg" />
                </IconButton>
              </Tooltip>
              <Menu
                sx={{ mt: "45px" }}
                id="menu-appbar"
                anchorEl={anchorElUser}
                anchorOrigin={{
                  vertical: "top",
                  horizontal: "right",
                }}
                keepMounted
                transformOrigin={{
                  vertical: "top",
                  horizontal: "right",
                }}
                open={Boolean(anchorElUser)}
                onClose={handleCloseUserMenu}
              >
                <MenuItem onClick={handleCloseUserMenu}>
                  <Link id="profileButton" to="/MyProfile">
                    <Typography color="common.black" textAlign="center">
                      Profile
                    </Typography>
                  </Link>
                </MenuItem>
                <MenuItem onClick={handleSignOut}>
                  <Typography color="common.black" textAlign="center">
                    Log Out
                  </Typography>
                </MenuItem>
              </Menu>
            </Box>
          ) : (
            <Link to="login">
              <Button
                variant="contained"
                style={{ backgroundColor: "#00176A" }}
              >
                Sign In
              </Button>
            </Link>
          )}
        </Toolbar>
      </Container>
    </AppBar>
  );
}
export default ResponsiveAppBar;