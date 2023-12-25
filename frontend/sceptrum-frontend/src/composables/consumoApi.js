import http from '@/services/http.js';
import { useAuth } from '@/stores/auth.js';

const auth = useAuth();

export default function consumoApi(url) {
    const tokenJwt = localStorage.getItem('token');

    // Método Get
    const metodoGet = async () => {
        try {
            const { data } = await http.get(url, {
                headers:{
                Authorization: `Bearer ${tokenJwt}`
            }
            });
            return data
        } catch (error) {
            throw new Error(error)
        }
    }

        // Método Get by id
        const metodoGetById = async (id) => {
            try {
                const { data } = await http.get(`${url}/${id}`, {
                    headers:{
                    Authorization: `Bearer ${tokenJwt}`
                }
                });
                return data
            } catch (error) {
                throw new Error(error)
            }
        }

    // Método Post
    const metodoPost = async (dadosFormulario) => {
        try {
            const { data } = await http.post(url, dadosFormulario, {
                headers:{
                Authorization: `Bearer ${tokenJwt}`
                }
            });
            return data
        } catch (error) {
            throw new Error(error)
        }
    }

      // Método Update
      const metodoUpdate = async (dadosFormulario) => {
        console.log("dadosFormulario: " + JSON.stringify(dadosFormulario));
        try {
            const { data } = await http.put(`${url}?id=${dadosFormulario.id}`, dadosFormulario, {
                headers:{
                'Content-Type':'application/json',
                Authorization: `Bearer ${tokenJwt}`
                }
            });
            return data
        } catch (error) {
            throw new Error(error)
        }
      }
        // Método Delete
      const metodoDelete = async (id) => {
        try {
            const { data } = await http.delete(`${url}/${id}`, {
                headers:{                
                Authorization: `Bearer ${tokenJwt}`
                }
            });
            return data
        } catch (error) {
            console.error(error.response ? error.response.data : error);
        }
    }

    return {
        metodoGet,
        metodoGetById,
        metodoPost,
        metodoUpdate,
        metodoDelete
    }
}