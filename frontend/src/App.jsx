import {
  BrowserRouter,
  Routes,
  Route
} from "react-router-dom";

import Login from "./pages/Login";
import Dashboard from "./pages/Dashboard";
import Products from "./pages/Products";
import NotFound from "./pages/NotFound";
import ProtectedRoute from "./routes/ProtectedRoute";

import DashboardLayout from "./layouts/DashboardLayout";
import Categories from "./pages/Categories";
import Inventory from "./pages/Inventory";
import Users from "./pages/Users";

function App() {
  return (
    <BrowserRouter>

      <Routes>

        <Route
          path="/login"
          element={<Login />}
        />

        <Route element={<DashboardLayout />}>

          <Route
            path="/"
            element={
              <ProtectedRoute>
                  <Dashboard />
              </ProtectedRoute>
            }
          />

          <Route path="/products" element={
            <ProtectedRoute>
              <Products />
            </ProtectedRoute>
          } />

          <Route path="/categories" element={
            <ProtectedRoute>
              <Categories />
            </ProtectedRoute>
          } />

          <Route path="/inventory" element={
            <ProtectedRoute>
              <Inventory />
            </ProtectedRoute>
          } />

          <Route path="/users" element={
            <ProtectedRoute>
              <Users />
            </ProtectedRoute>
          } />

        </Route>

        <Route
          path="*"
          element={<NotFound />}
        />

      </Routes>

    </BrowserRouter>
  );
}

export default App;