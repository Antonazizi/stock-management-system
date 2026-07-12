import { useEffect, useState } from "react";
import { getCurrentUser } from "../api/authApi";

export default function Dashboard() {

    const [user, setUser] = useState(null);

    useEffect(() => {
        loadUser();
    }, []);

    const loadUser = async () => {

        try {
            const data = await getCurrentUser();
            setUser(data);
        }
        catch (err) {
            console.log(err);
        }
    };

    return (

        <div>

            <h1 className="text-3xl font-bold">
                Dashboard
            </h1>

            {user && (

                <div className="mt-6">

                    <p>
                        Username:
                        {user.username}
                    </p>

                    <p>
                        Role:
                        {user.role}
                    </p>

                </div>

            )}

        </div>

    );
}