import React, { useContext, useEffect, useState } from 'react'
import useInsurer from '../../hook/useInsurer';
import InputText from './InputText';
import NumberField from './NumberField';
import CheckboxInput from './CheckboxInput';
import { Button, Box } from '@mui/material';
import Alerting from '../Alert';

const Form = () => {

    const [name, setName] = useState('');
    const [isApproved, setIsApproved] = useState(false); 
    const [id, setId] = useState(0); 
    const [commission, setCommission] = useState(0); 
    const { saveInsurer, insurer, setError, error } = useInsurer(); 
  
    
   const [alert, setAlert] = useState({});
   
    useEffect(() => {
        if (insurer?.name) {
            setName(insurer.name);
            setIsApproved(insurer.isApproved);
            setCommission(insurer.commission);

            setId(insurer.id);

        }
    }, [insurer]); 

    const handleSubmit = async e => {
        e.preventDefault(); 

         
            //validations 
            if (parseFloat(commission) >25) {
                setAlert({
                    msg: 'La comision no puede ser mayor a 25',
                    error:true
                })
                return;
                
                
            } else if(name.length > 45){
                setAlert({ msg: 'Has excedido el limite' ,error:true});
                return;
            }
            let result = await saveInsurer({ id, name, commission, isApproved });
                
            

            if (result) {
                setAlert({msg:'Guardado correctamente'})
                setName('');
                setCommission(0); 
                setId();
                setIsApproved(false); 
                //setErrors({});
              // setAlert({msg:'Congrats'})
               
                
                
            } else {
                setAlert({
                    msg: 'Aseguradora registrada', 
                    error:true
                })
                
                
            }
              
       
            
            
        }


    const { msg } = alert;
  //  const { msg } = alert;
    return (
        <div>
            {msg&&<Alerting alert={alert}/>}
      
    <form onSubmit={handleSubmit}>
         
    <InputText
         id="name"
         label="Nombre"
         value={name}
         onChange={e => setName(e.target.value)}
          />
          <Box my={2} />
     <NumberField
         id="commission"
         label="Comisión"
         value={commission}
         onChange={e => setCommission(e.target.value)}
          />
            <Box my={2} />
     <CheckboxInput
         id="isApproved"
         label="Aprobado"
         checked={isApproved}
         onChange={()=>setIsApproved(!isApproved)}
          />
            <Box my={2} />
     <Button type="submit" variant="contained">
         {id? 'Guardar Cambios': 'Agregar'}
        </Button>
        
        
        
            </form>
            </div>
    )
}


export default Form;
