import React from "react";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
//import Navbar from "./components/navbar/Navbar";
import TaskList from "./components/TaskCard/TaskCard"; 

const routes = [
  { path: "/tasks", element: TaskList },
];

function App() {
  return (
    <Router>
      <div className="main-container">
        <Routes>
          {routes.map((route, index) => (
            <Route
              path={route.path}
              key={index}
              element={<route.element />}
            />
          ))}
          {/* Default Route */}
          <Route path="/" element={<h1>Welcome to Task Management</h1>} />
          <Route path="*" element={<h1>404 - Page Not Found</h1>} />
        </Routes>
      </div>
    </Router>
  );
}

export default App;
