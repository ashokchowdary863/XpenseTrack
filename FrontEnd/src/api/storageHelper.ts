export const Token = "xpense_track_auth_token";

export const SetToken = (token: string) => {
  localStorage.setItem(Token, token);
};

export const GetToken = () => {
  return localStorage.getItem(Token);
};

export const RemoveToken = () => {
  localStorage.removeItem(Token);
};
