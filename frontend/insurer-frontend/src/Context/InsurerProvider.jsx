import axios from 'axios'; 
import { createContext,useEffect, useState } from 'react';
import { config } from '../helper/config';


const InsurerContext = createContext(); 
const InsurerProvider = ({ children }) => {
    const [insurers, setInsurers] = useState([]);
    const [insurer, setInsurer] = useState({});
    const [error, setError] = useState({}); 

    const API_URL = 'https://localhost:5001/api/insurers';
    
    useEffect(() => {
       
        getInsurers();
    
    }, []);

    


    const getInsurers = async () => {
        
        try {
           
    
            const { data } = await axios.get(API_URL, config);
            setInsurers(data);
    
        } catch (error) {
            setError(error.response.data); 
            
        }
    }

    const saveInsurer = async (insurer) => {
        if (insurer.id) {
            try {
                const { data } = await axios.put(`${API_URL}/${insurer.id}`, insurer, config); 
                const updatedInsurer = insurers.map(insurerState => insurerState.id === data.id ? data : insurerState); 
                setInsurers(updatedInsurer); 
                getInsurers();
            } catch (error) {
                setError(error.response.data); 
                return false;
            }
        }
        else {
            try {
                const { data } = await axios.post(API_URL, insurer,config); 
               

                setInsurers([...insurers, data]); 
                console.log(data)
            }
            catch (error) {
                setError(error.response.data);
                return false; 
            }
        }
        return true; 

        
    }

      
    const setEdit = (insurer) => setInsurer(insurer); 

    const deleteInsurer = async id => {
        const confirma = confirm('Esta seguro que quiere eliminarla?'); 
        if (confirma) {
            try {
                const { data } = await axios.delete(`${API_URL}/${id}`, config); 
                const updatedInsurers = insurers.filter(insurersState => insurersState.id !== id); 
                setInsurers(updatedInsurers);
            
            } catch (error) {
                setError(error.response.data);
                
            }
            
        }
    }
    


    return (
        <InsurerContext.Provider
            value={{
                insurers,
                saveInsurer, 
                setEdit, 
                insurer, 
                deleteInsurer, 
                setError,
                error
            }}
        >
            {children}
        </InsurerContext.Provider> 

    )
}

export {
    InsurerProvider
}
export default InsurerContext;