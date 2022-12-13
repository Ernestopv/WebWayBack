import Frame from "./components/Frame";
import { Home } from "./components/Home";

const AppRoutes = [
  {
    index: true,
    element: <Home />,
  },
  {
    path: "/frame",
    element: <Frame />,
  },
];

export default AppRoutes;
