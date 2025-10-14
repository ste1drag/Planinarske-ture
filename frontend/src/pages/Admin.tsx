import { useEffect, useState } from 'react';
import { getAllUsers, assignTourGuideRole } from '@/features/auth/api/user-api';
import { UserDetailsDTO } from '@/features/auth/types/auth-types';

export default function Admin() {
  const [users, setUsers] = useState<UserDetailsDTO[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);
  const [assigningUserId, setAssigningUserId] = useState<string | null>(null);

  useEffect(() => {
    loadUsers();
  }, []);

  const loadUsers = async () => {
    try {
      setLoading(true);
      const usersData = await getAllUsers();
      setUsers(usersData);
    } catch (err: any) {
      setError(err.response?.data?.message || 'Failed to load users');
    } finally {
      setLoading(false);
    }
  };

  const handleAssignTourGuide = async (userId: string) => {
    try {
      setAssigningUserId(userId);
      await assignTourGuideRole(userId);
      alert('TourGuide role assigned successfully!');
      await loadUsers();
    } catch (err: any) {
      alert(err.response?.data?.message || 'Failed to assign TourGuide role');
    } finally {
      setAssigningUserId(null);
    }
  };

  if (loading) {
    return (
      <div className="container mx-auto p-6">
        <div className="text-center">Loading users...</div>
      </div>
    );
  }

  if (error) {
    return (
      <div className="container mx-auto p-6">
        <div className="text-red-500 text-center">{error}</div>
      </div>
    );
  }

  return (
    <div className="container mx-auto p-6">
      <h1 className="text-3xl font-bold mb-6">User Management</h1>
      <p className="text-gray-600 mb-6">
        Assign TourGuide role to users to allow them to create and manage tours.
      </p>

      <div className="bg-white shadow-md rounded-lg overflow-hidden">
        <table className="min-w-full divide-y divide-gray-200">
          <thead className="bg-gray-50">
            <tr>
              <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
                Name
              </th>
              <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
                Email
              </th>
              <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
                Actions
              </th>
            </tr>
          </thead>
          <tbody className="bg-white divide-y divide-gray-200">
            {users.map(userData => (
              <tr key={userData.id}>
                <td className="px-6 py-4 whitespace-nowrap">
                  <div className="text-sm font-medium text-gray-900">
                    {userData.firstName} {userData.lastName}
                  </div>
                </td>
                <td className="px-6 py-4 whitespace-nowrap">
                  <div className="text-sm text-gray-500">{userData.email}</div>
                </td>
                <td className="px-6 py-4 whitespace-nowrap text-sm font-medium">
                  <button
                    onClick={() => handleAssignTourGuide(userData.id)}
                    disabled={assigningUserId === userData.id}
                    className="text-white bg-blue-600 hover:bg-blue-700 px-4 py-2 rounded disabled:opacity-50 disabled:cursor-not-allowed"
                  >
                    {assigningUserId === userData.id
                      ? 'Assigning...'
                      : 'Assign TourGuide Role'}
                  </button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
}
