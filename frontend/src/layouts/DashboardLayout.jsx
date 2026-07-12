import { Outlet } from "react-router-dom";

export default function DashboardLayout() {
  return (
    <div className="min-h-screen bg-gray-100">
      <div className="flex">

        <aside className="w-64 bg-white border-r min-h-screen p-4">
          <h2 className="text-xl font-bold">
            Stock Management
          </h2>
        </aside>

        <main className="flex-1 p-6">
          <Outlet />
        </main>

      </div>
    </div>
  );
}