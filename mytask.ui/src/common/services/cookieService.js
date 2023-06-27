import Cookies from 'js-cookie'

export const RemoveToken = () =>  {
    Cookies.remove('token');
}
export const SaveToken = (token) => {
    Cookies.set('token', token);
}
export const GetToken = () => Cookies.get('token');
