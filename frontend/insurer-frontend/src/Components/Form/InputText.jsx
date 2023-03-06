import React from 'react'
import { TextField } from '@mui/material'

const InputText = ({label,value,onChange,...rest}) => {
    return (
        <TextField
            label={label || 'Name'}
            variant="outlined"
            size="small"
            value={value}

            
            onChange={onChange}
            {...rest}
        />
      
    
    );
}

export default InputText;
