import axios from 'axios';

const API_BASE_URL = '';

export const axios_instance = axios.create({ baseURL: API_BASE_URL });
