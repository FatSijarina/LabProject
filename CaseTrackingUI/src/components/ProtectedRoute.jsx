import React from "react";
import { Navigate } from "react-router-dom";
import { useAppSelector } from "../store/configureStore.ts";

const ProtectedRoute = ({ children }) => {
  const { user } = useAppSelector((state) => state.account);

  // If the user is not logged in, redirect to the login page
  if (!user) {
    return <Navigate to="/login" />;
  }

  // If the user is logged in, render the children components
  return children;
};

export default ProtectedRoute;