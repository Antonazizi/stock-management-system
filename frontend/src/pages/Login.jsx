import { useState } from "react";
import { useNavigate } from "react-router-dom";

import { loginUser } from "../api/authApi";
import { useAuth } from "../context/AuthContext";

export default function Login() {

    const navigate = useNavigate();

    const { login } = useAuth();

    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");

    const handleSubmit = async (e) => {

        e.preventDefault();

        try {

            const response =
                await loginUser({
                    username,
                    password
                });

            login(response.token);

            navigate("/");

        }
        catch {

            alert("Login failed");
        }
    };

    return (

        <div
            className="flex items-center justify-center min-h-screen bg-gray-100 "
        >

            <form
                onSubmit={handleSubmit}
                className="p-8 bg-white shadow-md rounded-xl w-96"
            >

                <h1
                    className="mb-6 text-3xl font-bold "
                >
                    Login
                </h1>

                <input
                    type="text"
                    placeholder="Username"
                    value={username}
                    onChange={(e) =>
                        setUsername(e.target.value)
                    }
                    className="w-full p-3 mb-4 border rounded-lg "
                />

                <input
                    type="password"
                    placeholder="Password"
                    value={password}
                    onChange={(e) =>
                        setPassword(e.target.value)
                    }
                    className="w-full p-3 mb-4 border rounded-lg "
                />

                <button
                    className="w-full py-3 text-white bg-blue-600 rounded-lg "
                >
                    Login
                </button>

            </form>

        </div>
    );
}