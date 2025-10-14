export const decodeJWT = (token: string): any => {
  try {
    const base64Url = token.split('.')[1];
    const base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
    const jsonPayload = decodeURIComponent(
      atob(base64)
        .split('')
        .map(c => '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2))
        .join('')
    );
    return JSON.parse(jsonPayload);
  } catch (error) {
    console.error('Error decoding JWT:', error);
    return null;
  }
};

export const getRolesFromToken = (token: string): string[] => {
  const decoded = decodeJWT(token);
  if (!decoded) return [];

  const roleClaim =
    decoded['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];

  if (!roleClaim) return [];

  // Role claim can be a string (single role) or array (multiple roles)
  return Array.isArray(roleClaim) ? roleClaim : [roleClaim];
};
