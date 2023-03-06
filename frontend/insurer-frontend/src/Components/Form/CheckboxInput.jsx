import React from 'react'
import { FormControlLabel, Checkbox } from '@mui/material'; 

const CheckboxInput = ({ label, value, onChange, ...rest }) => {
    return (
        <FormControlLabel
            control={
                <Checkbox
                    checked={value}
                    onChange={onChange}
                    {...rest}
                
                />
            }
            label={label}
        />
            
      
  )
}

export default CheckboxInput
