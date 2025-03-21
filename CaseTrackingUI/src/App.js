import "./styles/App.scss";
import Navbar from "./components/navbar/navbar";
import { LandingPage, TaskList, CaseList, Case, ProvaList, Login, Register, Statistics, MyProfile} from "./pages/index";
import { Route, Routes } from "react-router-dom";
import { useAppDispatch, useAppSelector } from "./store/configureStore.ts";
import { fetchCurrentUser } from "./pages/Account/AccountSlice.ts";
import { useCallback, useEffect, useState } from "react";
import Footer from "./components/Footer/Footer";

const routes = [
  {path: "/landingPage", element: LandingPage},
  {path: "/cases", element: CaseList},
  {path: "/tasks", element: TaskList},
  {path: "/case/:caseId", element: Case},
  {path: "/provat", element: ProvaList},
  {path: "/statistics", element: Statistics},
  {path: "/myprofile", element: MyProfile},
];

function App() {
  const dispatch = useAppDispatch();
  const [loading, setLoading] = useState(true);

  const initApp = useCallback(async () => {
    try {
      await dispatch(fetchCurrentUser());
    } catch (error) {
      console.log(error);
    }
  }, [dispatch]);

  useEffect(() => {
    initApp().then(() => setLoading(false));
  }, [initApp])

  return (
    <div className="main-container">
      <Navbar />
      <div className="back"></div>
      {loading ? <CaseList /> : 
        <Routes>
          {routes.map((route) => (
            <Route
              path={route.path}
              key={route.key}
              element={
                  <route.element />
              }
            />
          ))}
          <Route path="/login" element={<Login />} />
          <Route path="/register" element={<Register />} />
          <Route path="/" element={<LandingPage />} />
          <Route path="*" element={<LandingPage />} />
        </Routes>
      }
      <Footer />
    </div>
  );
}

export default App;