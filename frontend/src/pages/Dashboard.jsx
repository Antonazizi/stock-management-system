export default function Dashboard() {

  return (

    <div>

      <h1
        className="mb-6 text-3xl font-bold "
      >
        Dashboard
      </h1>

      <div
        className="grid grid-cols-4 gap-6 "
      >

        <div className="p-5 bg-white shadow rounded-xl">
          <h3>Total Products</h3>
          <p className="text-3xl font-bold">
            0
          </p>
        </div>

        <div className="p-5 bg-white shadow rounded-xl">
          <h3>Categories</h3>
          <p className="text-3xl font-bold">
            0
          </p>
        </div>

        <div className="p-5 bg-white shadow rounded-xl">
          <h3>Low Stock</h3>
          <p className="text-3xl font-bold">
            0
          </p>
        </div>

        <div className="p-5 bg-white shadow rounded-xl">
          <h3>Users</h3>
          <p className="text-3xl font-bold">
            0
          </p>
        </div>

      </div>

    </div>
  );
}