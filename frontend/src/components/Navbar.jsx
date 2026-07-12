import { useAuth } from "../context/AuthContext";

export default function Navbar() {

  const { logout } = useAuth();

  return (

    <header
      className="flex items-center justify-between px-6 py-4 bg-white border-b "
    >

      <h2 className="font-semibold">
        Dashboard
      </h2>

      <button
        onClick={logout}
        className="px-4 py-2 text-white bg-red-500 rounded "
      >
        Logout
      </button>

    </header>
  );
}