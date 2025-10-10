export interface NewUserDTO {
  FirstName: string;
  LastName: string;
  UserName: string;
  Password: string;
  Email: string;
  PhoneNumber: string;
}

export interface UserCredentialsDTO {
  UserName: string;
  Password: string;
}

export interface AuthenticationModel {
  AccessToken: string;
  RefreshToken: string;
  isAuthorized: boolean;
}

export interface RefreshTokenModel {
  UserName: string;
  RefreshToken: string;
}

