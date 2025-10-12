export interface NewUserDTO {
  firstName: string;
  lastName: string;
  userName: string;
  password: string;
  email: string;
  phoneNumber: string;
}

export interface UserCredentialsDTO {
  userName: string;
  password: string;
}

export interface AuthenticationModel {
  name: string;
  userName: string;
  accessToken: string;
  refreshToken: string;
  isAuthorized: boolean;
}

export interface RefreshTokenModel {
  userName: string;
  refreshToken: string;
}

