import { Link } from "react-router-dom";

export default function Sidebar() {
  return (
    <aside className="w-64 min-h-screen text-white bg-slate-900">

      <div className="p-6 border-b border-slate-700">
        <h1 className="text-xl font-bold">
          Stock Management
        </h1>
      </div>

      <nav className="p-4">

        <Link
          to="/"
          className="block p-3 rounded hover:bg-slate-800"
        >
          Dashboard
        </Link>

        <Link
          to="/products"
          className="block p-3 rounded hover:bg-slate-800"
        >
          Products
        </Link>

        <Link
          to="/categories"
          className="block p-3 rounded hover:bg-slate-800"
        >
          Categories
        </Link>

        <Link
          to="/inventory"
          className="block p-3 rounded hover:bg-slate-800"
        >
          Inventory
        </Link>

        <Link
          to="/users"
          className="block p-3 rounded hover:bg-slate-800"
        >
          Users
        </Link>

      </nav>

    </aside>
  );
}